namespace Binding.Analysis

module Program = 
    open System
    open Environment
    open ConfigurationReader
    
    let showBindings (sites : List<BoundSite>) = 
        for site in sites do
            printfn "%s (%s)" site.Url site.Path
    
    let print path sites = 
        printfn "Directory: '%s'" path
        printf "Usage: "
        match sites with
        | [] -> 
            Console.ForegroundColor <- ConsoleColor.Red
            printf "not used\n"
            Console.ForegroundColor <- ConsoleColor.White
        | _ -> 
            Console.ForegroundColor <- ConsoleColor.Green
            printf "used\n"
            Console.ForegroundColor <- ConsoleColor.White
            showBindings sites
        printfn ""
            
    let explore directories = 
        use explorer = new BindingsExplorer()
        directories |> Array.iter (fun directory -> print directory (explorer.findSites directory))
    
    [<EntryPoint>]
    let main argv = 
        Console.ForegroundColor <- ConsoleColor.White
        printfn "Welcome to IIS bindings usage analysis tool!\n"
        try 
            let root = getWebsitesRoot
            collectSubDirectories root |> explore
        with ex -> printfn "%s" ex.Message
        printfn "Press any key to exit..."
        let key = Console.ReadLine()
        0
