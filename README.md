[![](https://img.shields.io/nuget/v/soenneker.launchdarkly.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.launchdarkly.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.launchdarkly.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.launchdarkly.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.launchdarkly.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.launchdarkly.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.launchdarkly.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.launchdarkly.openapiclient/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.LaunchDarkly.OpenApiClient

Call LaunchDarkly management endpoints through a Kiota-generated client with typed request builders and models.

## Install

```bash
dotnet add package Soenneker.LaunchDarkly.OpenApiClient
```

## Create a client

```csharp
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.LaunchDarkly.OpenApiClient;

var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://app.launchdarkly.com/")
};
httpClient.DefaultRequestHeaders.Add("Authorization", accessToken);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient);

var client = new LaunchDarklyOpenApiClient(adapter);
```

LaunchDarkly management tokens are sent directly in the `Authorization` header without a `Bearer` prefix. Reuse the transport and dispose it with its owning application component. For application registration and coordinated ownership, use `Soenneker.LaunchDarkly.OpenApiClientUtil`.

## Call an endpoint

```csharp
using Soenneker.LaunchDarkly.OpenApiClient.Models;

CallerIdentityRep? identity = await client.Api.V2.CallerIdentity.GetAsync(
    cancellationToken: cancellationToken);
```

Follow `client.Api.V2` to request builders for projects, environments, flags, segments, teams, tokens, webhooks, and other management resources. HTTP failures are surfaced through Kiota exceptions; nullable results indicate no response body.

This repository contains generated code. Put reusable helpers and behavior changes in a separate package so regeneration does not overwrite them.
