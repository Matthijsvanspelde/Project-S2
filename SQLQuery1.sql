	SELECT [User].Id, FirstName, MiddleName, LastName, biography, ProfilePictures.[Data]
	FROM [User]
	LEFT OUTER JOIN ProfilePictures ON [User].Id = ProfilePictures.UserId
	WHERE CONCAT(FirstName, ' ' ,MiddleName, ' ' ,LastName) LIKE '%' + 'e' + '%'
	ORDER BY FirstName ASC