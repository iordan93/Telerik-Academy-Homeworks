/// <reference path="jquery-2.0.2.js" />

var token;

window.fbAsyncInit = function () {
    FB.init({
        appId: "650420584985598",
        status: true,
        cookie: true,
        xfbml: true
    });

    FB.login(function (response) {
        if (response.authResponse) {
            token = response.authResponse.accessToken;
            getProfileInfo();
            getFriends();
        }
    }, {
        scope: "read_friendlists,user_photos"
    });
};

(function (d) {
    var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
    if (d.getElementById(id)) {
        return;
    }
    js = d.createElement('script');
    js.id = id;
    js.async = true;
    js.src = "//connect.facebook.net/en_US/all.js";
    ref.parentNode.insertBefore(js, ref);
}(document));

function getProfileInfo() {
    FB.api('/me', function (response) {
        var holder = $("#profile");
        var name = response.name;
        var url = "https://graph.facebook.com/" + response.id + "/picture";
        holder.append("<img src =" + url + "/>");
        holder.append("<p>" + name + "</p>");
    });
    $("#log").css("display", "none");
}

function getFriends() {
    FB.api('/me/friends?access_token=' + token, function (response) {
        var friends = $('#friends');
        for (i = 0; i < response.data.length; i++) {
            var friendPictureUrl = 'https://graph.facebook.com/' + response.data[i].id + '/picture';
            var friendName = response.data[i].name;
            friends.append("<img src =" + friendPictureUrl + " title=" + friendName + "/>");
        }

        $("#friends").on("click", "img", function () {
            friends.children().css({
                width: "auto",
                height: "auto"
            });
            $(this).css({
                width: "150px",
            });
        });
    });
}