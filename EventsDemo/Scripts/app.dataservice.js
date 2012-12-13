; (function(window, app, $, undefined) {
    app.dataservice = (function() {
        var getEventListings = function(successful, failed) {
            $.ajax({
                url: '/api/events/list',
                type: 'GET',
                dataType: 'json',
                success: successful,
                error: failed
            });
        };


        var getPastEventListings = function(successful, failed) {
            $.ajax({
                url: '/api/events/past',
                type: 'GET',
                dataType: 'json',
                success: successful,
                error: failed
            });
        };

        var getUpcomingEventListings = function(successful, failed) {
            $.ajax({
                url: '/api/events/upcoming',
                type: 'GET',
                dataType: 'json',
                success: successful,
                error: failed
            });
        };

        var searchEventListings = function(searchTerm, successful, failed) {
            $.ajax({
                url: '/api/events/search?searchTerm=' + searchTerm,
                type: 'GET',
                dataType: 'json',
                success: successful,
                error: failed
            });
        };      

        return {
            getEventListings: getEventListings,
            getPastEventListings: getPastEventListings,
            getUpcomingEventListings: getUpcomingEventListings,
            searchEventListings: searchEventListings
        };
    }());

}(window, window.app = window.app || {}, jQuery));