A solution for WCF to support large file transform with streaming.
This solution contains 2 projects:
+ A wcf service to offer stram upload and download
+ A client to call the wcf service to do transfer

### Attention
Client holds two way of calling wcf:
+ one using app.config's binding configuration
+ one using coding to generate Binding object
