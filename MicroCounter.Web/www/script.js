var myRequests = [];

$(document).ready(function(){
    $("#post").click(function(){
        $.post("http://localhost/api/", function(data, status) {
            addToRequestList("POST", data, status);
        });
    });
});

$(document).ready(function(){
    $("#get").click(function(){
        $.get("http://localhost/api/", function(data, status) {
            addToRequestList("GET", data, status);
            updateCount(data);
        });
    });
});

function addToRequestList(type, data, status) {
    var requestObj = Object.freeze({time: new Date().toLocaleString(),type: type, data: data, status: status});
    myRequests.push(requestObj);

    $('#requests').empty();
    $.each(myRequests, function(i, p) {
        $('#requests').append($('<option></option>').val(i).html(p.time + ": " + p.type + ", " + p.status));
    });
}

function onRequestListChange() {
    var requestNumber = document.getElementById("requests").value;
    var data = myRequests[requestNumber].data;
    data = JSON.stringify(data, null, 4)
    document.getElementById("selectedRequestData").innerHTML = data;    
}

function updateCount(data) {
    document.getElementById("count").innerHTML = "Count: " + data;
}
