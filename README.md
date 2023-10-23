# PlantCare
Project uses endoints from https://docs.trefle.io/.

## HOW TO
1. In the appsettings.Development.json file find the following section:
  "TrefleApi": {
    "BaseUrl": "https://trefle.io/api/v1/",
    "ApiKey": "{PUT_KEY_HERE}", // It should be stored in the secured storage (ex Azure KeyVault)
    "ListPlantsEndpoint": "plants"
  }
2. Change ApiKey with the key which I sent by email or with Your key.
