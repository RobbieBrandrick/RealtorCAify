using System.Collections.Generic;

namespace RealtorCAify
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class ErrorCodeDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ProductName { get; set; }
        public string Version { get; set; }
    }

    public class PagingDto
    {
        public int RecordsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalRecords { get; set; }
        public int MaxRecords { get; set; }
        public int TotalPages { get; set; }
        public int RecordsShowing { get; set; }
        public int Pins { get; set; }
    }

    public class BuildingDto
    {
        public string BathroomTotal { get; set; }
        public string Bedrooms { get; set; }
        public string SizeInterior { get; set; }
        public string StoriesTotal { get; set; }
        public string Type { get; set; }
        public string Ammenities { get; set; }
    }

    public class AddressDto
    {
        public string AddressText { get; set; }
        public bool PermitShowAddress { get; set; }
        public object DisseminationArea { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }

    public class PhoneDto
    {
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public string AreaCode { get; set; }
        public string PhoneTypeId { get; set; }
    }

    public class EmailDto
    {
        public string ContactId { get; set; }
    }

    public class WebsiteDto
    {
        public string Website { get; set; }
        public string WebsiteTypeId { get; set; }
    }

    public class OrganizationDto
    {
        public int OrganizationID { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public AddressDto Address { get; set; }
        public List<PhoneDto> Phones { get; set; }
        public List<EmailDto> Emails { get; set; }
        public List<WebsiteDto> Websites { get; set; }
        public string OrganizationType { get; set; }
        public string Designation { get; set; }
        public bool HasEmail { get; set; }
        public bool PermitFreetextEmail { get; set; }
        public bool PermitShowListingLink { get; set; }
        public string RelativeDetailsURL { get; set; }
        public string PhotoLastupdate { get; set; }
    }

    public class IndividualDto
    {
        public int IndividualID { get; set; }
        public string Name { get; set; }
        public OrganizationDto Organization { get; set; }
        public List<PhoneDto> Phones { get; set; }
        public List<EmailDto> Emails { get; set; }
        public string Photo { get; set; }
        public string Position { get; set; }
        public bool PermitFreetextEmail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CorporationDisplayTypeId { get; set; }
        public bool PermitShowListingLink { get; set; }
        public string RelativeDetailsURL { get; set; }
        public string AgentPhotoLastUpdated { get; set; }
        public string PhotoHighRes { get; set; }
        public string RankMyAgentKey { get; set; }
        public string RealSatisfiedKey { get; set; }
        public List<WebsiteDto> Websites { get; set; }
    }

    public class PhotoDto
    {
        public string SequenceId { get; set; }
        public string HighResPath { get; set; }
        public string MedResPath { get; set; }
        public string LowResPath { get; set; }
        public string LastUpdated { get; set; }
        public string Description { get; set; }
    }

    public class ParkingDto
    {
        public string Name { get; set; }
    }

    public class PropertyDto
    {
        public string Price { get; set; }
        public string Type { get; set; }
        public AddressDto Address { get; set; }
        public List<PhotoDto> Photo { get; set; }
        public List<ParkingDto> Parking { get; set; }
        public string TypeId { get; set; }
        public string ConvertedPrice { get; set; }
        public string ParkingType { get; set; }
        public string PriceUnformattedValue { get; set; }
        public string OwnershipType { get; set; }
        public List<int> OwnershipTypeGroupIds { get; set; }
    }

    public class BusinessDto
    {
    }

    public class LandDto
    {
        public string SizeTotal { get; set; }
        public string SizeFrontage { get; set; }
        public string AccessType { get; set; }
    }

    public class MediumDto
    {
        public string MediaCategoryId { get; set; }
        public string MediaCategoryURL { get; set; }
        public int Order { get; set; }
    }

    public class AlternateURLDto
    {
        public string VideoLink { get; set; }
    }

    public class ResultDto
    {
        public string Id { get; set; }
        public string MlsNumber { get; set; }
        public string PublicRemarks { get; set; }
        public BuildingDto Building { get; set; }
        public List<IndividualDto> Individual { get; set; }
        public PropertyDto Property { get; set; }
        public BusinessDto Business { get; set; }
        public LandDto Land { get; set; }
        public string PostalCode { get; set; }
        public string RelativeDetailsURL { get; set; }
        public string StatusId { get; set; }
        public string PhotoChangeDateUTC { get; set; }
        public string Distance { get; set; }
        public string RelativeURLEn { get; set; }
        public string RelativeURLFr { get; set; }
        public List<MediumDto> Media { get; set; }
        public AlternateURLDto AlternateURL { get; set; }
        public bool? HasNewImageUpdate { get; set; }
    }

    public class PinDto
    {
        public string key { get; set; }
        public string propertyId { get; set; }
        public int count { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
    }

    public class RealtorResponseDto
    {
        public ErrorCodeDto ErrorCode { get; set; }
        public PagingDto Paging { get; set; }
        public List<ResultDto> Results { get; set; }
        public List<PinDto> Pins { get; set; }
        public string GroupingLevel { get; set; }
    }
    
    public class RealtorRequestDto
    {
        public int CultureId { get; set; }
        public int ApplicationId { get; set; }
        public string ZoomLevel { get; set; }
        public string Center { get; set; }
        public string LatitudeMax { get; set; }
        public string LongitudeMax { get; set; }
        public string LatitudeMin { get; set; }
        public string LongitudeMin { get; set; }
        public string view { get; set; }
        public string Sort { get; set; }
        public string PGeoIds { get; set; }
        public string GeoName { get; set; }
        public string PropertyTypeGroupID { get; set; }
        public string PropertySearchTypeId { get; set; }
        public string TransactionTypeId { get; set; }
        public string PriceMin { get; set; }
        public string PriceMax { get; set; }
        public string Currency { get; set; }
        public string RecordsPerPage { get; set; }
    }

}