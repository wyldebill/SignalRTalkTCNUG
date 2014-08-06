$(function() {

    // step 1. get a reference to the signalr hub
    var progHub = $.connection.progressHub;


    
    // step 2. set the clientside functions
    progHub.client.RecMessage = function(msg) {
        console.log(msg);
    };

    progHub.client.setValue = function(val, time) {
        $('#test > span').animate({
            width: (val + '%')
        }, time, function() {
            // Animation complete.
        });
            
    };

    progHub.client.setClient50 = function() {
        $('#test > span').animate({
            width: '50%'
        }, 200, function() {
            // Animation complete.
        });
    };

    progHub.client.setClient100 = function () {
        $('#test > span').animate({
            width: '100%'
        }, 200, function () {
            // Animation complete.
        });
    };
        
    progHub.client.setClient0 = function () {
        $('#test > span').animate({
            width: '0%'
        }, 200, function () {
            // Animation complete.
        });
    };
        

    progHub.client.youAreNotTheMaster = function () {
        $('[id$=percent]').hide();
        $('#iAmTheMaster').hide();
        $('#auto').hide();
        $('#key').hide();
    };

    progHub.client.setMaster = function() {
        $('#iAmTheMaster').css('color', 'green');
    };
    


    // step 3. call start on the hub, use .done and .fail
    $.connection.hub.logging = true;
    $.connection.hub.start()
    .done(function () {
        console.log('Now connected, connection ID=' + $.connection.hub.id);

        // step 4.  setup the functions to call on server
        // this is defining messages the server can call on me
        $('#0percent').click(function () {
            progHub.server.set0();
        });
        $('#50percent').click(function () {
            progHub.server.set50();
        });
        $('#100percent').click(function () {
            progHub.server.set100();
        });


        $('#auto').click(function () {
            progHub.server.auto();
        });

        $('#iAmTheMaster').click(function () {
            var secret = $('#key').val();
            progHub.server.iAmTheMaster(secret);
        });




    })
    .fail(function() {
         console.log('Could not Connect!');
    });


});