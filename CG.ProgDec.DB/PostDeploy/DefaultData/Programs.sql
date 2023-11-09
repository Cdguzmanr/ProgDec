BEGIN
	INSERT INTO [dbo].tblProgram (Id, Description, DegreeTypeId, ImagePath)
	VALUES
	(1, 'Computer Support Specialist', 1, 'CSS.jpg'),
	(2, 'Network Specialist', 1, 'NetworkAdmin.jpg'),
	(3, 'Network System Adminstration', 1, 'SysAdmin.jpg'),
	(4, 'Software Development', 1, 'SoftwareDeveloper.jpg'),
	(5, 'Web Development and Design', 1, 'WebDev.jpg'),
	(6, 'Help Desk Specialist', 2, 'helpdesk.jpg'),
	(7, 'Database', 3, 'NetworkAdmin.jpg'),
	(8, 'Desktop Support', 3, 'helpdesk.jpg'),
	(9, 'IT Security', 3, 'helpdesk.jpg'),
	(10, 'Mobile Application Development', 3, 'mobile.jpg'),
	(11, 'Network Administration', 3, 'NetworkAdmin.jpg'),
	(12, 'Network Infrastructure', 3, 'NetworkAdmin.jpg'),
	(13, 'PC Programming', 3, 'SoftwareDeveloper.jpg'),
	(14, 'Web Design', 2, 'WebDev.jpg'),
	(15, 'Web Design', 3, 'WebDev.jpg'),
	(16, 'Web Development', 3, 'WebDev.jpg')
END