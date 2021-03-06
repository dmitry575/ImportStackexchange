using System.Collections.Generic;
using CommandLine;
using ImportStackexchange.Enums;

namespace ImportStackexchange.Config
{
    /// <summary>
    /// Options for program
    /// </summary>
    public class ConfigOptions
    {
        // [Option('t', "type", Required = false, Default = TypeFile.All, HelpText = "Set type of file: All, Votes, Users, Tags, PostLinks, Posts, PostHistory, Comments, Badges")]
        // public TypeFile FileName { get; set; }

        [Option('c', "check", Required = false, Default = true, HelpText = "Set flag checking tables and create before insert")]
        public bool CheckExists { get; set; }

        [Option('p', "path", Required = false, Default = "./", HelpText = "Set paths where xml files")]
        public string WorkPath { get; set; }
        
        [Value(0, MetaName = "offset", HelpText = "Set list of files need parsing: All, Votes, Users, Tags, PostLinks, Posts, PostHistory, Comments, Badges. You can use several of files type. Write the name separated by a space")]
        public IEnumerable<string> FileNames { get; set; }

    }
}
