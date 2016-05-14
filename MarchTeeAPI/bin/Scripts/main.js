$(document).ready(function(){
  
  /* Scroll down on clicking homepage arrow */
  
  $('.opening').ready(function() {
    $('.more').fadeIn(200);
  });
  
  $('.more').click(function(event){
    event.preventDefault();
    $("body, html").animate({ 
        scrollTop: $(window).height()
    }, 800);
  });
  
  /* Set footer height to fit the grid*/
  
  var setFooterHeight = function(){
    if($(window).width() > $(window).height()){
      $('footer').css('height', $(window).width() / 4)
    }
    else{
      $('footer').css('height', $(window).width())
    }
  };
  setFooterHeight();
  
  $(window).resize(function() {
    setFooterHeight();
  });
  
/*  $(document).scroll(function() {
    var scroll = $(this).scrollTop();
    if (Modernizr.touchevents) {
      $('header').css({'position': 'absolute', 'top': '100%', 'display': 'block'});
    } else {
      if (scroll > $(window).height()){
        $('header').fadeIn(200);
      } 
      else{
        $('header').fadeOut(200);
      };
    }
  });*/
  
  /* Header show/hide stuff */
  
  $(document).scroll(function() {
    var scroll = $(this).scrollTop();
    if (scroll > $(window).height() - 1){
      $('header').addClass('show');
    } 
    else{
      $('header').removeClass('show');
    };
  }); 
  
  /* Button disabled at first */
  
  $( "#fieldEmail" ).keypress(function() {
    $(".soon button").removeClass('disabled');
  });
  
  
  /* Ajax with Campaign Monitor */
  
  $(function () {
        $('#subForm').submit(function (e) {
            e.preventDefault();
            $.getJSON(
            this.action + "?callback=?",
            $(this).serialize(),
            function (data) {
                if (data.Status === 400) {
                    $('.fail').show();
                } else { // 200
                    $('.success').show();
                    $('#subForm #fieldEmail').val('');
                }
            });
        });
    });
  
});
