
    // Get the video
    var video = document.getElementById("myVideo");
    
    // Get the button
    var btn = document.getElementById("myBtn");
    
    // Pause and play the video, and change the button text
function myFunction() {
  if (video.paused) {
        video.play();
    btn.innerHTML = "Pause";
  } else {
        video.pause();
    btn.innerHTML = "Play";
  }
}
$(document).ready(function () {
    $body = $('body').width();
    $video = $('#myVideo').width();

    console.log($body);
    console.log($video);
    if ($body > $video) {
        $('#myVideo').css({
            width: "100%",
            height: "auto"
        });
    } else {
        $('#myVideo').css({
            left: ($video - $body) / -2
        });
    }
});

