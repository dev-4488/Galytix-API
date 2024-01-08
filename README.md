# GalytixAPI
This service provides APIs for providing data insights using a csv file.

**Prerequisites**

.NET Core SDK


**Getting Started**

Clone this repository:
git clone <repository_url>

cd GalytixAPI


**Run the application:**

dotnet run

Use an API testing tool like Postman to interact with the following endpoints:

use the postman collection checked-in repository to test the API.

Generate Access token: POST /connect/token

Get the average premium data : POST /server/api/gwp/avg

**Configuration**

Modify appsettings.json to set path of the csv file to load data from:

"CSVFilePath": "{path to csv file here}",

Additional Notes
See the example folder for the format of csv file which can be used.
Ensure proper security configurations, such as HTTPS, CORS settings, and input validation, before deploying this service in production.
For development purposes, consider setting up secure environments, managing secrets securely, and conducting security reviews.
