# .Net Core Graph API Playground

You can find an example of a Graph API application with Brand and Product domains in this playground prepared with .NetCore 3.1. It uses InMemory, so it has no dependencies. To start tampering, simply run with the command 'dotnet run'. It includes Queries (pagination supported) and Mutations application.

I tried the subscriptions capabilities on WebSocket, but I did not send it to this repo as it would cause confusion for the visitors at the beginning.


### Some Information
GraphQL runs under `/api/v1`. If you open with **[GET]**, you can view the scheme produced by *SchemaPrinter *. You can start tampering by sending GraphQL queries with the **[POST]** method...

Includes GraphiQL ❤, you can access it via `/ui/graphiql`.

### Definations
Default Size Limit: 10

Max Size Limit: 10 (If you try set over limit, default size limit is assigned.)

---
**### TÜRKÇE ###**

.NetCore 3.1 ile hazırlanmış bu oyun alanında Brand ve Product domainlerine sahip bir Graph API uygulamasının örneğini bulabilirsiniz. InMemory kullanır, bu nedenle herhangi bir bağımlılığı yoktur. Kurcalamaya başlamak için `dotnet run` komutu ile çalıştırmanız yeterlidir. İçerisinde Queries (sorgu) [sayfalama destekli] ve Mutations (değişim) uygulaması bulunmakta.

Subscriptions (abonelik) yeteneklerini WebSocket üzerinden denedim fakat başlangıçta inceleyenler için karışıklığa neden olacağından bu repo içerisine göndermedim, denemek istediğinizde takıldığınız noktalarda elimden geldiğince destek olmaya çalışırım.


### Bazı Bilgiler
GraphQL `/api/v1` altında çalışmaktadır. **[GET]** ile açmanız halinde *SchemaPrinter* tarafından üretilen şemayı görüntüleyebilirsiniz. **[POST]** metodu ile GraphQL sorguları göndererek kurcalamaya başlayabilirsiniz...

GraphiQL ❤️ içerir, `/ui/graphiql` yolundan erişebilirsiniz.

### Tanımlar
Varsayılan Limit: 10
Üst Limit: 10 (Eğer daha büyük bir değer gelirse varsayılan limit geçerli olur.)