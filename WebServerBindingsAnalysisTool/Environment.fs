namespace Binding.Analysis

module internal Environment =
    
    open System.IO
    
    let private formatErrorMessage argument = 
        sprintf "The path '%s' does not exists. Please correct application settings." argument

    let collectSubDirectories root =
        let doesExists = Directory.Exists root
        match doesExists with
        | false -> raise <| new IOException(formatErrorMessage root)
        | true -> Directory.GetDirectories root    


