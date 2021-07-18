<<<<<<< HEAD
SELECT
    *
FROM
    Listings L1
WHERE
        DATE(L1.CreateDate) = DATE('now')
  AND NOT EXISTS (
        SELECT
            *
        FROM
            Listings L2
        WHERE
                DATE(L2.CreateDate) < DATE('now')
          AND L2.MlsNumber = L1.MlsNumber
    )
=======
SELECT 
	* 
FROM 
	Listings L1
WHERE
	DATE(L1.CreateDate) = DATE('now')
	AND NOT EXISTS (
		SELECT 
			* 
		FROM 
			Listings L2
		WHERE
			DATE(L2.CreateDate) < DATE('now')
			AND L2.MlsNumber = L1.MlsNumber
	)
	