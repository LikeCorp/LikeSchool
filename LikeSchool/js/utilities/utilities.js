
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

function parseDate(str) {
    var mdy = str.split('/')
    return new Date(mdy[2], mdy[0] - 1, mdy[1]);
}
function parseDbDate(str) {

    var mdy = str.split('-');
    return new Date(mdy[0], mdy[1]-1, mdy[2]);
}

function daydiff(first, second) {
    return (second - first) / (1000 * 60 * 60 * 24)
}

function measureText(pText, pFontSize) {
    var lDiv = document.createElement('lDiv');

    document.body.appendChild(lDiv);

    lDiv.style.fontSize = "" + pFontSize + "px";
    lDiv.style.position = "absolute";
    lDiv.style.left = -1000;
    lDiv.style.top = -1000;

    lDiv.innerHTML = pText;

    var lResult = {
        width: lDiv.clientWidth,
        height: lDiv.clientHeight
    };

    document.body.removeChild(lDiv);
    lDiv = null;

    return lResult;
}

function GetText(pText, desiredWidth, pFontSize) {

    var textWidth = measureText(pText, pFontSize);
    if (textWidth > desiredWidth) {
        return pText.val().slice(0, 50);
    }
    return pText;
}