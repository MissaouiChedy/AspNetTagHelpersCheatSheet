﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetTagHelpersCheatSheet.TagHelpers
{
    public class Holder
    {
        public int Id { get; set; }
    }

    public class WithArgumentsTagHelper : TagHelper
    {
        public int NumberArg { get; set; }
        public string StringArg { get; set; }
        public Holder ObjectArg { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.SetHtmlContent($@"Number -> {NumberArg} 
StringArg -> {StringArg} 
ObjectArg.Id -> {ObjectArg.Id}");
        }
    }
}