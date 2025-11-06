# REST API Weather Observation

This project is built with **.NET** and **Swagger UI** to demonstrate basic REST API functionality.

## Run
The simplest way to start the API is through **Visual Studio** or by running:
dotnet run

## Authentication
Authentication uses an API key added to the request header:
- Key: X-API-Key
- Value: Test-API-Key

## Send Requests
While the application is running, you can make requests via:
- **Localhost**: https://localhost:7224/api/observations
- **Swagger UI**: https://localhost:7224/swagger/index.html

Use the following query parameters to filter observations:

| Parameter   | Type     | Description                                    |
| ----------- | -------- | ---------------------------------------------- |
| `stationId` | `long`   | ID of the weather station                      |
| `period`    | `string` | One of: `last-hour`, `hour`, `last-day`, `day` |

## Example
curl -H "X-API-Key: Test-API-Key" \
     "https://localhost:7224/api/observations?stationId=123&period=last-hour"
