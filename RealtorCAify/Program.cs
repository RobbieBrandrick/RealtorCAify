using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using RealtorCAify.Data;
using RealtorCAify.Models;
using RestSharp;

namespace RealtorCAify
{
    class Program
    {
        private const string BaseUrl = "https://api2.realtor.ca";

        static async Task Main(string[] args)
        {
            var result = await GetListings();

            await SaveListings(result);
        }

        private static async Task SaveListings(RealtorResponseDto results)
        {
            List<Listing> listings = new List<Listing>();
            
            foreach (var result in results.Results)
            {
                var listing = new Listing()
                {
                    Price = result?.Property?.Price ?? "",
                    AddressText = result?.Property?.Address?.AddressText ?? "",
                    MlsNumber = result?.MlsNumber ?? "",
                    ResultDtoId = result?.Id,
                    BathroomTotal = result?.Building?.BathroomTotal ?? "",
                    Bedrooms = result?.Building?.Bedrooms ?? "",
                    SizeInterior = result?.Building?.SizeInterior ?? "",
                    StoriesTotal = result?.Building?.StoriesTotal ?? "",
                    Type = result?.Building?.Type ?? "",
                    Ammenities = result?.Building?.Ammenities ?? "",
                    SizeTotal = result?.Land?.SizeTotal ?? "",
                    SizeFrontage = result?.Land?.SizeFrontage ?? "",
                    AccessType = result?.Land?.AccessType ?? "",
                    PostalCode = result?.PostalCode ?? "",
                    PropertyDescription = result?.PublicRemarks ?? "",
                    RealtorName = result?.Individual?.FirstOrDefault()?.Name ?? "",
                    DetailsUrl = result?.RelativeDetailsURL,
                };
                
                listings.Add(listing);
            }
            
            await using RealtorCAifyDbContext dbContext = new RealtorCAifyDbContext();
            await dbContext.Listings.AddRangeAsync(listings);
            await dbContext.SaveChangesAsync();
        }

        private static async Task<RealtorResponseDto> GetListings()
        {
            var client = new RestClient(BaseUrl);

            RestRequest request = new RestRequest("/Listing.svc/PropertySearch_Post", Method.POST);

            SetupRequestHeaders(request);

            SetupRequestBody(request);

            IRestResponse<RealtorResponseDto> response = await client.ExecutePostAsync<RealtorResponseDto>(request);

            await SaveApiTransaction(client, request, response);

            RealtorResponseDto result = response.Data;
            return result;
        }

        private static async Task SaveApiTransaction(RestClient client, RestRequest request,
            IRestResponse<RealtorResponseDto> response)
        {
            var requestToLog = new
            {
                resource = request.Resource,
                // Parameters are custom anonymous objects in order to have the parameter type as a nice string
                // otherwise it will just show the enum value
                parameters = request.Parameters.Select(parameter => new
                {
                    name = parameter.Name,
                    value = parameter.Value,
                    type = parameter.Type.ToString()
                }),
                // ToString() here to have the method as a nice string otherwise it will just show the enum value
                method = request.Method.ToString(),
                // This will generate the actual Uri used in the request
                uri = client.BuildUri(request),
            };

            var responseToLog = new
            {
                statusCode = response.StatusCode,
                content = response.Content,
                headers = response.Headers,
                // The Uri that actually responded (could be different from the requestUri if a redirection occurred)
                responseUri = response.ResponseUri,
                errorMessage = response.ErrorMessage,
            };

            await using RealtorCAifyDbContext dbContext = new RealtorCAifyDbContext();
            await dbContext.ApiTransactions.AddAsync(new ApiTransaction()
            {
                Resource = request.Resource,
                Request = JsonConvert.SerializeObject(requestToLog),
                Response = JsonConvert.SerializeObject(responseToLog),
                CreateDate = DateTime.Now
            });
            await dbContext.SaveChangesAsync();
        }

        private static void SetupRequestBody(RestRequest restRequest)
        {
            RealtorRequestDto requestDto = new RealtorRequestDto()
            {
                CultureId = 1,
                ApplicationId = 37,
                ZoomLevel = "11",
                Center = "Center=48.402436%2C-89.236990",
                LatitudeMax = "48.54560",
                LatitudeMin = "48.25886",
                LongitudeMax = "-88.91392",
                LongitudeMin = "-89.56006",
                view = "list",
                Sort = "1-D",
                PGeoIds = "=g30_f08e2tde",
                GeoName = "Thunder%20Bay%2C%20ON",
                PropertyTypeGroupID = "1",
                PropertySearchTypeId = "1",
                TransactionTypeId = "2",
                PriceMin = "200000",
                PriceMax = "450000",
                Currency = "CAD",
                RecordsPerPage = "500",
            };

            foreach (var property in requestDto.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                restRequest.AddParameter(property.Name, property.GetValue(requestDto) ?? "", ParameterType.GetOrPost);
            }
        }

        private static void SetupRequestHeaders(RestRequest restRequest)
        {
            restRequest.AddHeader("Host", "api2.realtor.ca");
            restRequest.AddHeader("User-Agent",
                "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:88.0) Gecko/20100101 Firefox/88.0");
            restRequest.AddHeader("Accept", "*/*");
            restRequest.AddHeader("Accept-Language", "en-CA,en-US;q=0.7,en;q=0.3");
            restRequest.AddHeader("Accept-Encoding", "gzip, deflate, br");
            restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            restRequest.AddHeader("Content-Length", "291");
            restRequest.AddHeader("Origin", "https://www.realtor.ca");
            restRequest.AddHeader("DNT", "1");
            restRequest.AddHeader("Connection", "keep-alive");
            restRequest.AddHeader("Referer", "https://www.realtor.ca/");
            restRequest.AddHeader("Cookie", "");
            restRequest.AddHeader("Pragma", "no-cache");
            restRequest.AddHeader("Cache-Control", "no-cache");
            restRequest.AddHeader("TE", "Trailers");
        }
    }
}