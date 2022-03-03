namespace Binding.Analysis

type BoundSite(path : string, url : string) =

    let path = path
    let url = url

    member this.Path with get() = path
    member this.Url with get() = url
