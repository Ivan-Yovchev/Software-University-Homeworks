var poppy = poppy || {};

(function (scope) {
    var OPACITY_STEP = 0.04,
        FADE_INTERVAL = 40;

    function pop(type, title, message, callback) {
        var popup;
        switch (type) {
            case "success":
                popup = new scope._models.Success(title, message);
                break;
            case "info":
                popup = new scope._models.Info(title, message);
                break;
            case "error":
                popup = new scope._models.Error(title, message);
                break;
            case 'warning':
                popup = new scope._models.Warning(title, message, callback);
                break;
        }
        
        // generate view from view factory
        var view = scope._viewfactory.createPopupView(popup);
        processPopup(view, popup);
    }

    function fadeIn(element) {
        var opacity = 0,
            disappearInterval = setInterval(function () {
                if (opacity >= 1) {
                    clearInterval(disappearInterval);
                }
                
                element.style.opacity = opacity;
                opacity += OPACITY_STEP;
            }, FADE_INTERVAL);
    }
    
    function fadeOut(element) {
        var opacity = 1,
            disappearInterval = setInterval(function () {
                if (opacity <= 0) {
                    clearInterval(disappearInterval);
                }
                
                element.style.opacity = opacity;
                opacity -= OPACITY_STEP;
            }, FADE_INTERVAL);
    }

    function processPopup(domView, popup) {
        if (popup._popupData.autoHide === true) {
            setTimeout(function () {
                fadeOut(domView, FADE_INTERVAL);
            }, popup._popupData.timeout);
        }

        if (popup._popupData.closeButton === true) {
            domView.getElementsByClassName('poppy-close-button')[0]
            .addEventListener('click', function () {
                fadeOut(domView);
            });
        }
        
        if (popup._popupData.callback) {
            domView.addEventListener("click", function() {
                popup._popupData.callback();
            });
        }

        domView.style.opacity = 0;
        document.body.appendChild(domView);
        fadeIn(domView);
    }

    scope.pop = pop;
})(poppy);