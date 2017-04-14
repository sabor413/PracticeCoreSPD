CREATE TABLE WebsiteStats
(
ID int IDENTITY(1,1) PRIMARY KEY,
Host varchar(255) NOT NULL,
PageViews int NOT NULL,
SiteVisits int NOT NULL,
TopKeywords varchar(255) NOT NULL,
Bandwidth int NOT NULL
)