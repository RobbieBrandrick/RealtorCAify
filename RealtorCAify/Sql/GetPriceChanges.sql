
SELECT DISTINCT
    L1.MlsNumber
              , 'realtor.ca' || L1.DetailsUrl
              ,	L1.AddressText
              , L1.CreateDate as BeforeCreateDate
              , L1.Price AS BeforePrice
              , L2.CreateDate as AfterCreateDate
              , L2.Price As AfterPrice
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
      AND DATE(L3.CreateDate) = DATE('now', '-1 day')
)
  AND L2.CreateDate = (
    SELECT
        MAX(L3.CreateDate)
    FROM
        Listings L3
    WHERE
            L3.MlsNumber = L1.MlsNumber
      --AND L3.CreateDate >= '2021-07-12'
      AND DATE(L3.CreateDate) = DATE('now')
)
ORDER BY
	L1.AddressText
