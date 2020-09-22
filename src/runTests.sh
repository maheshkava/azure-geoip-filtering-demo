printf "Running Tests from US"
curl -X POST https://customer-demo-client-us.azurewebsites.net/api/testAppGateway?code=$code
printf "\n"
curl -X POST https://customer-demo-client-us.azurewebsites.net/api/testContentDeliveryNetwork?code=$code
printf "\n"
curl -X POST https://customer-demo-client-us.azurewebsites.net/api/testFrontDoor?code=$code
printf "\n"
printf "Running Tests from Germany"
curl -X POST https://customer-demo-client-germany.azurewebsites.net/api/testAppGateway?code=$code
printf "\n"
curl -X POST https://customer-demo-client-germany.azurewebsites.net/api/testContentDeliveryNetwork?code=$code
printf "\n"
curl -X POST https://customer-demo-client-germany.azurewebsites.net/api/testFrontDoor?code=$code
printf "\n"
