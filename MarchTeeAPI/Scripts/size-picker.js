//ok
$(document).ready(function(){
    
    var setHeadWidth = function(){
        var head = $('.head'); 
        $(head).width(head.height());
    }
    
    var setHeight = function(){ 
        var containerHeight = $('#size-picker-ui').height();
        $('.height-result').html(((containerHeight / 5.555556 + 12) / 12).toFixed(1));
        
    };
    
    var setWeight = function(){   
        var containerWidth = $('#size-picker-ui').width();
        $('.weight-result').html((containerWidth - 60).toFixed(0));
    };
    
    var sizeResult = $('.size-result');
    
    var setSizeWithHeight = function(e){
        var currentWeight = $('.weight-result').text();
        var currentHeight = $('.height-result').text() * 12;
        if (currentWeight <= 60){
            if(currentHeight <= 72){
              sizeResult.html('S');  
            }
            else{
              sizeResult.html('M');    
            }
        }
        if (currentWeight > 60 && currentWeight <= 80){
            if(currentHeight <= 60){
              sizeResult.html('S');  
            }
            else if(currentHeight > 60 && currentHeight < 72){
              sizeResult.html('M');  
            }
            else{
              sizeResult.html('L');  
            }
        }
        if (currentWeight > 80 && currentWeight <= 100){
            if(currentHeight <= 60){
              sizeResult.html('M');  
            }
            else{
              sizeResult.html('L');  
            }
        }
        if (currentWeight > 100 && currentWeight <= 120){
            if(currentHeight <= 60){
              sizeResult.html('L');  
            }
            else{
              sizeResult.html('XL');  
            }
        }
        if (currentWeight > 121 && currentWeight <= 160){
            if(currentHeight <= 60){
              sizeResult.html('L');  
            }
            else{
              sizeResult.html('XL');  
            }
        }
    };
    
    var setSizeWithWeight = function(e){
        var currentWeight = $('.weight-result').text();
        var currentHeight = $('.height-result').text() * 12;
        if (currentHeight <= 60){
            if(currentWeight <= 70){
              sizeResult.html('S');  
            }
            else{
              sizeResult.html('M');    
            }
        }
        if (currentHeight > 60 && currentHeight <= 72){
            if(currentWeight <= 60){
              sizeResult.html('S');  
            }
            else if(currentWeight > 60 && currentWeight <= 80){
              sizeResult.html('M');  
            }
            else if(currentWeight > 80 && currentWeight <= 120){
              sizeResult.html('L');  
            }
            else{
              sizeResult.html('XL');  
            }
        }
        if (currentHeight > 72 && currentHeight <= 84){
            if(currentWeight <= 80){
              sizeResult.html('L');  
            }
            else{
              sizeResult.html('XL');  
            }
        }
        if (currentHeight > 84){
            if(currentWeight <= 60){
              sizeResult.html('L');  
            }
            else{
              sizeResult.html('XL');  
            }
        }
    };

    
    setHeight();
    setWeight();
    setSizeWithHeight();
    setSizeWithWeight();
    setHeadWidth();
    
    $('#size-picker-ui').resizable({
        maxHeight: 400,
        maxWidth: 220,
        minHeight: 200,
        minWidth: 100,
        aspectRatio: false,
        resize: function(event, ui) {
            $(this).css({
                'top': parseInt(ui.position.top, 10) + ((ui.originalSize.height - ui.size.height)) / 2,
                'left': parseInt(ui.position.left, 10) + ((ui.originalSize.width - ui.size.width)) / 2
            });
            setHeight();
            setWeight();
            setSizeWithHeight();
            setSizeWithWeight();
            setHeadWidth();
        }
    });
    
})
