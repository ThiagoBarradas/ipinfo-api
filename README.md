[![CircleCI](https://circleci.com/gh/ThiagoBarradas/ipinfo-api/tree/master.svg?style=svg)](https://circleci.com/gh/ThiagoBarradas/ipinfo-api/tree/master)
[![codecov](https://codecov.io/gh/ThiagoBarradas/ipinfo-api/branch/master/graph/badge.svg)](https://codecov.io/gh/ThiagoBarradas/ipinfo-api)

# IpInfo Api

A simple web API that implements *ipinfo.io* to get ip details, like geolocation.

## Getting started

1. Clone this project and run.
2. To access API resources, you can use **IpInfo.Api.Client**

## How to use

Request:
**GET /ip/{ip}** 
Ex.: GET /ip/201.200.168.63

Response 200 OK:
```json
{
    "latitude": -22.905346,
    "longitude": -43.176523, 
    "city": "Rio de Janeiro",
    "state" : "Rio de Janeiro",
    "country" : "BR"
}
```

# How can I contribute?
Please, refer to [CONTRIBUTING](CONTRIBUTING.md)

# Found something strange or need a new feature?
Open a new Issue following our issue template [ISSUE-TEMPLATE](ISSUE-TEMPLATE.md)

# Changelog
See in [releases](https://github.com/ThiagoBarradas/ipinfo-api/releases)

