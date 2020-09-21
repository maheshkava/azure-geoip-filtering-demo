using namespace System.Net

# Input bindings are passed in via param block.
param($Request, $TriggerMetadata)

# Write to the Azure Functions log stream.
Write-Host "PowerShell HTTP trigger function processed a request."

$uri = "http://customer-demo.eastus.cloudapp.azure.com/"
$statusCode = [HttpStatusCode]::OK
$body = "It looks good!"

Try {
    Invoke-WebRequest -Uri $uri -ErrorAction Stop
} Catch {
    $body = "Request Failed :("
    $statusCode = [HttpStatusCode]::InternalServerError
}

# Associate values to output bindings by calling 'Push-OutputBinding'.
Push-OutputBinding -Name Response -Value ([HttpResponseContext]@{
    StatusCode = $statusCode
    Body = $body
})
