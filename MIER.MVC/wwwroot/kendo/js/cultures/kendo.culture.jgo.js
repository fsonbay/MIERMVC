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
    kendo.cultures["jgo"] = {
        name: "jgo",
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
                pattern: ["-$ n","$ n"],
                decimals: 0,
                ",": ".",
                ".": ",",
                groupSize: [3],
                symbol: "FCFA"
            }
        },
        calendars: {
            standard: {
                days: {
                    names: ["S????ndi","M????ndi","??pta M????ndi","W????n??s??d??","T????s??d??","F??l??y??d??","S??sid??"],
                    namesAbbr: ["S????ndi","M????ndi","??pta M????ndi","W????n??s??d??","T????s??d??","F??l??y??d??","S??sid??"],
                    namesShort: ["S????ndi","M????ndi","??pta M????ndi","W????n??s??d??","T????s??d??","F??l??y??d??","S??sid??"]
                },
                months: {
                    names: ["Ndu??mbi Sa??","P??sa?? P????p??","P??sa?? P????t??t","P??sa?? P????n????kwa","P??sa?? Pataa","P??sa?? P????n????nt??k??","P??sa?? Saamb??","P??sa?? P????n????f??m","P??sa?? P????n????pf???????","P??sa?? N??g????m","P??sa?? Nts????pm????","P??sa?? Nts????pp??"],
                    namesAbbr: ["Ndu??mbi Sa??","P??sa?? P????p??","P??sa?? P????t??t","P??sa?? P????n????kwa","P??sa?? Pataa","P??sa?? P????n????nt??k??","P??sa?? Saamb??","P??sa?? P????n????f??m","P??sa?? P????n????pf???????","P??sa?? N??g????m","P??sa?? Nts????pm????","P??sa?? Nts????pp??"]
                },
                AM: ["mba???mba???","mba???mba???","MBA???MBA???"],
                PM: ["??ka mb????t nji","??ka mb????t nji","??KA MB????T NJI"],
                patterns: {
                    d: "yyyy-MM-dd",
                    D: "dddd, yyyy MMMM dd",
                    F: "dddd, yyyy MMMM dd HH:mm:ss",
                    g: "yyyy-MM-dd HH:mm",
                    G: "yyyy-MM-dd HH:mm:ss",
                    m: "MMMM d",
                    M: "MMMM d",
                    s: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                    t: "HH:mm",
                    T: "HH:mm:ss",
                    u: "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                    y: "yyyy MMMM",
                    Y: "yyyy MMMM"
                },
                "/": "-",
                ":": ":",
                firstDay: 1
            }
        }
    }
})(this);
}));