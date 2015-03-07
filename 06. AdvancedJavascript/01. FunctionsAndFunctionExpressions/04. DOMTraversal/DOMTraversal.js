function traverse(selector) {
    var node = document.querySelector(selector);
    
    if (node !== undefined && node !== null) {
        traverseNode(node, '');
    }
    
    function traverseNode(node, spacing) {
        
        spacing = spacing || '  ';
        
        var info = node.nodeName;
        var nodeId = node.getAttribute('id');
        var nodeClass = node.getAttribute('class');
        
        if (node.id) {
            console.log(info += ': id="' + node.id + '"');
        }
        
        if (node.className) {
            console.log(info += ': class="' + node.className + '"');
        }
        
        for (var i = 0; i < node.childNodes.length; i++) {
            var child = node.childNodes[i];
            if (child.nodeType === document.ELEMENT_NODE) {
                traverseNode(child, spacing + '  ');
            }
        }
    }
}

var selector = ".birds";
traverse(selector);