## Project Structure

### Engine.Library
The core of the application. Contains all model classes and business logic.

##Models:
- `ApiResponse` - Wraps the API response
- `Order` - Represents an order from ChannelEngine
- `OrderItem` - Represents a product inside an order
- `ProductResult` - Represents the top 5 product results
- `StockUpdate` - Represents the data sent to update stock
- `StockLocation` - Represents the warehouse location
- `StockLocationUpdate` - Represents the stock update per location

**Business Logic (OrderService):**
- `GetInProgressOrders` - Fetches all orders with status 
  IN_PROGRESS from the API and deserializes the JSON response 
  into C# objects
- `GetTopFiveProducts` - Calculates the top 5 products based 
  on total quantity sold, ordered by descending order
- `UpdateStock` - Updates the stock of a product to 25 
  using a PUT request

### Engine.Console
Console application entry point. Fetches IN_PROGRESS orders, 
displays the top 5 products in the terminal and updates 
the stock of the #1 product to 25.

### Engine.Web
ASP.NET Web application entry point. Displays the top 5 products 
in an interactive HTML table with:
- Sortable columns
- Gold highlight for #1 product
### Engine.Tests
Unit tests for the business logic. Tests the `GetTopFiveProducts` 
method using dummy data to verify correct ranking and 
quantity calculation.
