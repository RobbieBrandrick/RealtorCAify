
SELECT DISTINCT
	L1.MlsNumber 
  , 'realtor.ca' + L1.DetailsUrl
  ,	L1.AddressText
  , L1.CreateDate as CreateDate1
  , L1.Price AS Price1
  , L2.CreateDate as CreateDate1
  , L2.Price As Price2
FROM 
	Listings L1
	JOIN Listings L2 ON L1.MlsNumber = L2.MlsNumber
WHERE
	L1.Price <> L2.Price
	AND L1.CreateDate = (
		SELECT 
			MIN(L3.CreateDate) 
		FROM 
			Listings L3 
		WHERE 
			L3.MlsNumber = L1.MlsNumber 
			--AND L3.CreateDate >= '2021-07-12'
		)
	AND L2.CreateDate = (
		SELECT 
			MAX(L3.CreateDate) 
		FROM 
			Listings L3 
		WHERE 
			L3.MlsNumber = L1.MlsNumber 
			--AND L3.CreateDate >= '2021-07-12'
		)		
ORDER BY
	L1.AddressText
