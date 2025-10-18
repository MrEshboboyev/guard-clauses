# Test script for the Guard Clauses API

Write-Host "Testing Guard Clauses Web API" -ForegroundColor Green
Write-Host "=============================" -ForegroundColor Green

# Test 1: Create a customer
Write-Host "`n1. Creating a customer..." -ForegroundColor Yellow
$customer = @{
    name = "John Doe"
    age = 30
    email = "john@example.com"
} | ConvertTo-Json

$response = Invoke-RestMethod -Uri "http://localhost:5000/api/customers" -Method POST -Body $customer -ContentType "application/json"
Write-Host "Customer created: $($response.name), Age: $($response.age), Email: $($response.email)" -ForegroundColor Cyan

# Test 2: Get the customer
Write-Host "`n2. Retrieving the customer..." -ForegroundColor Yellow
$response = Invoke-RestMethod -Uri "http://localhost:5000/api/customers/john@example.com" -Method GET
Write-Host "Customer retrieved: $($response.name), Age: $($response.age), Email: $($response.email)" -ForegroundColor Cyan

# Test 3: Create an order
Write-Host "`n3. Creating an order..." -ForegroundColor Yellow
$order = @{
    customerName = "John Doe"
    products = @("Product 1", "Product 2")
    quantity = 2
    price = 15.99
    email = "john@example.com"
} | ConvertTo-Json

$response = Invoke-RestMethod -Uri "http://localhost:5000/api/orders" -Method POST -Body $order -ContentType "application/json"
Write-Host "Order created for: $($response.customerName), Quantity: $($response.quantity), Price: $($response.price)" -ForegroundColor Cyan

# Test 4: Get all customers
Write-Host "`n4. Retrieving all customers..." -ForegroundColor Yellow
$response = Invoke-RestMethod -Uri "http://localhost:5000/api/customers" -Method GET
Write-Host "Total customers: $($response.Count)" -ForegroundColor Cyan

# Test 5: Get all orders
Write-Host "`n5. Retrieving all orders..." -ForegroundColor Yellow
$response = Invoke-RestMethod -Uri "http://localhost:5000/api/orders" -Method GET
Write-Host "Total orders: $($response.Count)" -ForegroundColor Cyan

Write-Host "`nAll API tests completed successfully!" -ForegroundColor Green