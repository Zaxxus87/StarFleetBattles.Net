window.initializeKeyboardControls = (dotNetObjectReference) => {
    document.addEventListener('keydown', function (event) {
        // Prevent default behavior for game keys
        if (['ArrowUp', 'ArrowLeft', 'ArrowRight', 'KeyR', 'KeyE'].includes(event.code)) {
            event.preventDefault();
        }

        // Map event.code to key names
        let key = '';
        switch (event.code) {
            case 'ArrowUp':
                key = 'ArrowUp';
                break;
            case 'ArrowLeft':
                key = 'ArrowLeft';
                break;
            case 'ArrowRight':
                key = 'ArrowRight';
                break;
            case 'KeyR':
                key = 'R';
                break;
            case 'KeyE':
                key = 'E';
                break;
            case 'Escape':
                // Handle escape key if needed
                return;
            default:
                return; // Ignore other keys
        }

        // Call the C# method
        dotNetObjectReference.invokeMethodAsync('HandleKeyPress', key);
    });

    // Focus the document to ensure key events are captured
    document.focus();
};