function Declare(namespaceString, objectLiteral) {
    if (!namespaceString) {
        throw "namespaceString must be set";
    }
    var namespaceObj = window;
    var namespaceNames = namespaceString.split(".");
    for (var i = 0; i < namespaceNames.length; i++) {
        var name = namespaceNames[i];
        namespaceObj[name] = namespaceObj[name] || {};
        if (i === namespaceNames.length - 1) {
            namespaceObj[name] = $.extend(namespaceObj[name], objectLiteral);
        }
        namespaceObj = namespaceObj[name];
    }
    return objectLiteral;
}