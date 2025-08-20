window.GoogleMapsWrapper = {
    load: function (apiKey, scriptId) {
        return new Promise((resolve, reject) => {
            if (document.getElementById(scriptId) && window.google && window.google.maps) {
                resolve(true);
                return;
            }

            const script = document.createElement("script");
            script.id = scriptId;
            script.src = `https://maps.googleapis.com/maps/api/js?key=${apiKey}&libraries=maps,marker&v=beta`;
            script.async = true;
            script.defer = true;

            script.onload = () => {
                if (window.google && window.google.maps) {
                    resolve(true);
                } else {
                    reject("Google Maps API did not load correctly.");
                }
            };

            script.onerror = () => reject("Failed to load Google Maps script.");
            document.head.appendChild(script);
        });
    },

    initMap: function (elementId, lat, lng, desc) {
        const map = new google.maps.Map(document.getElementById(elementId), {
            center: { lat: lat, lng: lng },
            zoom: 18
        });

        new google.maps.Marker({
            position: { lat: lat, lng: lng },
            map: map,
            title: desc
        });
    }
};
