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
    kendo.cultures["agq"] = {
        name: "agq",
        numberFormat: {
            pattern: ["-n"],
            decimals: 2,
            ",": "??",
            ".": ",",
            groupSize: [3],
            percent: {
                pattern: ["-n%","n%"],
                decimals: 2,
                ",": "??",
                ".": ",",
                groupSize: [3],
                symbol: "%"
            },
            currency: {
                name: "",
                abbr: "",
                pattern: ["-n$","n$"],
                decimals: 0,
                ",": "??",
                ".": ",",
                groupSize: [3],
                symbol: "FCFA"
            }
        },
        calendars: {
            standard: {
                days: {
                    names: ["tsu??nts??","tsu??ukp??","tsu??ugh??e","tsu??ut????ml??","tsu??um??","tsu??ugh????m","tsu??ndz??k??????"],
                    namesAbbr: ["nts","kpa","gh??","t??m","ume","gh??","dzk"],
                    namesShort: ["nts","kpa","gh??","t??m","ume","gh??","dzk"]
                },
                months: {
                    names: ["ndz??????????n??m","ndz??????????k????z????","ndz??????????t????d????gh??","ndz??????????t??af????gh??","ndz????????s??e","ndz??????????nz??gh??","ndz??????????d??mlo","ndz??????????kw??f????e","ndz??????????t????f????gh??dzugh??","ndz??????????gh??uwel????m","ndz??????????chwa????kaa wo","ndz????????fw??o"],
                    namesAbbr: ["n??m","k??z","t??d","taa","see","nzu","dum","f??e","dzu","l??m","kaa","fwo"]
                },
                AM: ["a.g","a.g","A.G"],
                PM: ["a.k","a.k","A.K"],
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