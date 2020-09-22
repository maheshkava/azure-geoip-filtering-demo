# Retrieve keys for tests
code1=$(az functionapp keys list -n customer-demo-client-us -g customer-demo --query masterKey -o tsv)
code2=$(az functionapp keys list -n customer-demo-client-germany -g customer-demo --query masterKey -o tsv)
# Run tests
printf "Running Tests from US"
curl -d "" -X POST "https://customer-demo-client-us.azurewebsites.net/api/testAppGateway?code=$code1"
printf "\n"
curl -d "" -X POST "https://customer-demo-client-us.azurewebsites.net/api/testContentDeliveryNetwork?code=$code1"
printf "\n"
curl -d "" -X POST "https://customer-demo-client-us.azurewebsites.net/api/testFrontDoor?code=$code1"
printf "\n"
printf "Running Tests from Germany"
curl -d "" -X POST "https://customer-demo-client-germany.azurewebsites.net/api/testAppGateway?code=$code2"
printf "\n"
curl -d "" -X POST "https://customer-demo-client-germany.azurewebsites.net/api/testContentDeliveryNetwork?code=$code2"
printf "\n"
curl -d "" -X POST "https://customer-demo-client-germany.azurewebsites.net/api/testFrontDoor?code=$code2"
printf "\n"
