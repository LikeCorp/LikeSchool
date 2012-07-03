
/*This method returns the values is it is equal*/
function IsEqual(val1, val2) {
    return val1.toString() == val2.toString();
}

function GetJsonString(references, values) {    
    var jsonArray = [];
    for (var x = 0; x < references.length; x++) {
        
        jsonArray.push("'" + references[x] + "':'" + values[x] + "'");
    }
    return "{" +jsonArray.join(",").toString()+"}";
}