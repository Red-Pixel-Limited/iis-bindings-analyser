namespace Binding.Analysis

module internal ConfigurationReader =

    open System.Configuration
    
    let getWebsitesRoot = 
        let key = "WebsitesRoot"
        ConfigurationManager.AppSettings.[key]

