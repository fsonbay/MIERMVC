/** 
 * Kendo UI v2021.2.616 (http://www.telerik.com/kendo-ui)                                                                                                                                               
 * Copyright 2021 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.                                                                                      
 *                                                                                                                                                                                                      
 * Kendo UI commercial licenses may be obtained at                                                                                                                                                      
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete                                                                                                                                  
 * If you do not own a commercial license, this file shall be governed by the trial license terms.                                                                                                      
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       

*/

(function(f){
    if (typeof define === 'function' && define.amd) {
        define(["kendo.core"], f);
    } else {
        f();
    }
}(function(){
(function( window, undefined ) {
    kendo.cultures["ln"] = {
        name: "ln",
        numberFormat: {
            pattern: ["-n"],
            decimals: 2,
            ",": ".",
            ".": ",",
            groupSize: [3],
            percent: {
                pattern: ["-n%","n%"],
                decimals: 2,
                ",": ".",
                ".": ",",
                groupSize: [3],
                symbol: "%"
            },
            currency: {
                name: "",
                abbr: "",
                pattern: ["-n $","n $"],
                decimals: 2,
                ",": ".",
                ".": ",",
                groupSize: [3],
                symbol: "FC"
            }
        },
        calendars: {
            standard: {
                days: {
                    names: ["eyenga","mok??l?? mwa yambo","mok??l?? mwa m??bal??","mok??l?? mwa m??s??to","mok??l?? ya m??n??i","mok??l?? ya m??t??no","mp????s??"],
                    namesAbbr: ["eye","ybo","mbl","mst","min","mtn","mps"],
                    namesShort: ["eye","ybo","mbl","mst","min","mtn","mps"]
                },
                months: {
                    names: ["s??nz?? ya yambo","s??nz?? ya m??bal??","s??nz?? ya m??s??to","s??nz?? ya m??nei","s??nz?? ya m??t??no","s??nz?? ya mot??b??","s??nz?? ya nsambo","s??nz?? ya mwambe","s??nz?? ya libwa","s??nz?? ya z??mi","s??nz?? ya z??mi na m????k????","s??nz?? ya z??mi na m??bal??"],
                    namesAbbr: ["yan","fbl","msi","apl","mai","yun","yul","agt","stb","??tb","nvb","dsb"]
                },
                AM: ["nt????ng????","nt????ng????","NT????NG????"],
                PM: ["mp??kwa","mp??kwa","MP??KWA"],
                patterns: {
                    d: "d/M/yyyy",
                    D: "dddd d MMMM yyyy",
                    F: "dddd d MMMM yyyy HH:mm:ss",
                    g: "d/M/yyyy HH:mm",
                    G: "d/M/yyyy HH:mm:ss",
                    m: "MMMM d",
                    M: "MMMM d",
                    s: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                    t: "HH:mm",
                    T: "HH:mm:ss",
                    u: "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                    y: "yyyy MMMM",
                    Y: "yyyy MMMM"
                },
                "/": "/",
                ":": ":",
                firstDay: 1
            }
        }
    }
})(this);
}));