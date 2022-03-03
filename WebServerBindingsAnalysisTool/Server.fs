namespace Binding.Analysis

open System
open Microsoft.Web.Administration

type IBindingsExplorer<'T> =
    abstract member findSites : string -> 'T list

type BindingsExplorer() =

    let manager = new ServerManager() 

    member this.findSites path = (this :> IBindingsExplorer<BoundSite>).findSites path

    interface IBindingsExplorer<BoundSite> with
        member this.findSites path = 
            List.ofSeq<BoundSite>(
                query {
                    for site in manager.Sites do
                    for application in site.Applications do
                    for directory in application.VirtualDirectories do
                    where (directory.PhysicalPath = path)
                    select (new BoundSite(application.Path, site.Name))
                })

    interface IDisposable with
        member this.Dispose() = manager.Dispose()
    
        
