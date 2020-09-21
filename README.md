# azure-geoip-filtering-demo
Demonstrates GeoIP filtering using different Azure Services

## Showcased services

- [Azure Front Door](https://docs.microsoft.com/azure/frontdoor/)
- [Azure Content Delivery Network](https://docs.microsoft.com/azure/cdn/)
- [Azure Application Gateway w/WAF](https://docs.microsoft.com/azure/application-gateway/)

## Using this repo
Deploy using GitHub Actions or Azure Pipelines.

To deploy using GitHub Actions, you will need an AZURE_CREDENTIALS secret, see [this](https://github.com/marketplace/actions/azure-login) for more info.

## Notes
Configuration of the custom rules for the Azure Application Gateway w/WAF is only possible via ARM Templates or PowerShell, not through the Azure Portal as of the moment of this writing. More details [here](https://docs.microsoft.com/azure/web-application-firewall/ag/create-custom-waf-rules).

**WARNING**: These are not reusable templates, they have been exported from the Azure Portal and need cleanup to parameterize correctly and make them reliable.