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
    kendo.cultures["lkt"] = {
        name: "lkt",
        numberFormat: {
            pattern: ["-n"],
            decimals: 2,
            ",": ",",
            ".": ".",
            groupSize: [3],
            percent: {
                pattern: ["-n%","n%"],
                decimals: 2,
                ",": ",",
                ".": ".",
                groupSize: [3],
                symbol: "%"
            },
            currency: {
                name: "",
                abbr: "",
                pattern: ["-$ n","$ n"],
                decimals: 2,
                ",": ",",
                ".": ".",
                groupSize: [3],
                symbol: "$"
            }
        },
        calendars: {
            standard: {
                days: {
                    names: ["A??p??tuwak??a??","A??p??tuwa????i","A??p??tunu??pa","A??p??tuyamni","A??p??tutopa","A??p??tuzapta??","Ow????gyu??a??api"],
                    namesAbbr: ["A??p??tuwak??a??","A??p??tuwa????i","A??p??tunu??pa","A??p??tuyamni","A??p??tutopa","A??p??tuzapta??","Ow????gyu??a??api"],
                    namesShort: ["A??p??tuwak??a??","A??p??tuwa????i","A??p??tunu??pa","A??p??tuyamni","A??p??tutopa","A??p??tuzapta??","Ow????gyu??a??api"]
                },
                months: {
                    names: ["Wi??the??ika W??","Thiy????eyu??ka W??","I??t??wi??hayaza?? W??","P??e????t??o W??","??ha??w??pet??o W??","W??pazuk??a-wa??t?? W??","??ha??p????sapa W??","Was??t??u?? W??","??ha??w??pe??i W??","??ha??w??pe-kasn?? W??","Wan??yetu W??","T??ah??kap??u?? W??"],
                    namesAbbr: ["Wi??the??ika W??","Thiy????eyu??ka W??","I??t??wi??hayaza?? W??","P??e????t??o W??","??ha??w??pet??o W??","W??pazuk??a-wa??t?? W??","??ha??p????sapa W??","Was??t??u?? W??","??ha??w??pe??i W??","??ha??w??pe-kasn?? W??","Wan??yetu W??","T??ah??kap??u?? W??"]
                },
                AM: ["AM","am","AM"],
                PM: ["PM","pm","PM"],
                patterns: {
                    d: "M/d/yyyy",
                    D: "dddd, MMMM d, yyyy",
                    F: "dddd, MMMM d, yyyy h:mm:ss tt",
                    g: "M/d/yyyy h:mm tt",
                    G: "M/d/yyyy h:mm:ss tt",
                    m: "MMMM d",
                    M: "MMMM d",
                    s: "yyyy'-'MM'-'dd'T'HH':'mm':'ss",
                    t: "h:mm tt",
                    T: "h:mm:ss tt",
                    u: "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",
                    y: "yyyy MMMM",
                    Y: "yyyy MMMM"
                },
                "/": "/",
                ":": ":",
                firstDay: 0
            }
        }
    }
})(this);
}));