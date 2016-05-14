//ok
$(document).ready(function(){
    $("#ship-to").click(function(event){
        event.preventDefault();
        $("#friend-name").toggle('fast');
        if ($(this).text() == "Ship to me")
            $(this).text("Send to a friend");
        else
            $(this).text("Ship to me");
    });
	
		$(".swatches .swatch").click(function(event){
            event.preventDefault();
			$(".swatch").removeClass('selected');
			$(this).addClass('selected');
			$(".splash div").removeClass();
			$(".splash div").addClass(this.id);
			if ($(this).is("#grey")){
				$(".tee-details h3").text("Made from a Heathered Grey yarn, this short sleeves is an essential work-wear");
				$(".price").html('&#8377;1500');
			};
			if ($(this).is("#blue")){
				$(".tee-details h3").text("A dressy Denim Blue tee that comes with a subtle, elegant shine");
				$(".price").html('&#8377;2000');
			};
			if ($(this).is("#green")){
				$(".tee-details h3").text("This Mint green tee is solid, comfy and generally happy");
				$(".price").html('&#8377;1500');
			};
			if ($(this).is("#black")){
				$(".tee-details h3").text("The Classic Black short sleeves. More softer and way more richer");
				$(".price").html('&#8377;1500');
			};
		});
	
		$(".sizes .size").click(function(event){
            event.preventDefault();
			$(".size").removeClass('selected');
			$(this).addClass('selected');
		});
	
		$("#add-button").click(function(event){
            event.preventDefault();
            
            $('#cart-details').fadeIn(100);
            $('#cart').addClass('active').html(function(){
                var currentCount = $(this).html();
                return(parseInt(currentCount) + 1);
            });
		});
    
        $("#cart").click(function(event){
            event.preventDefault();
            $('#cart-details').toggle();
		});
    
        $("#gift-code").click(function(event){
            event.preventDefault();
			$(".gift-code-form").toggle('fast');
            if ($(this).text() == "No Code")
                $(this).text("Have a gift code?");
            else
                $(this).text("No Code");
        });
    
        $(document).mouseup(function(e){
            var summary = $("#cart-details");
            if (!summary.is(e.target)
                && summary.has(e.target).length === 0){
                summary.fadeOut(100);
            } 
        });
    
    $(function(){
        var overlay = ("<div class='popup-overlay'></div>");
            $("a#issue").click(function(e) {
                event.preventDefault();
                $("body").append(overlay);
                $(".popup-overlay").fadeTo(100, 0.7);
                $("#issue-popup").fadeIn(100);
            });  
        
        $('#dismiss-popup').click(function(event){
            event.preventDefault();
            $("#issue-popup").fadeOut(100);
            $(".popup-overlay").remove();
        });
    });
    
    $('.user-option').click(function(){
        $('.tab-content').show();
        $('.tabs').css('min-height', '360px');
    });
    
    
    $('.exchange-option').change(function(){ 
        if ($(this).val() != 'no-exchange') { 
            $(this).closest('.item').addClass('selected');
        }
        else
            $(this).closest('.item').removeClass('selected');
    });
    
    $('.select-return').click(function(event){  
        event.preventDefault();
        if ($(this).closest('.item').hasClass('selected')) { 
            $(this).closest('.item').removeClass('selected');
        }
        else
            $(this).closest('.item').addClass('selected');
    });
    
    $(function(){
        var overlay = ("<div class='popup-overlay'></div>");
            $("a#pick-size").click(function(e) {
                $("body").append(overlay);
                $(".popup-overlay").fadeTo(100, 0.7);
                $("#size-picker").show();
            });  
        
        $('#dismiss-popup').click(function(event){
            event.preventDefault();
            $("#size-picker").fadeOut(100);
            $(".popup-overlay").remove();
        });
    });
    
    
    var heightPicker = $('.height-picker input[type="range"]');
    var heightResult = $('.height-result');
    var weightPicker = $('.weight-picker input[type="range"]');
    var weightResult = $('.weight-result');
    var sizeResult = $('.size-result h1');
    
    function updateOutput(el, val) {
        el.textContent = val;
    }
    
    var setSizeWithHeight = function(e){
        var currentWeight = ($('.weight-result')).text();
        if (currentWeight <= 60){
            if(e <= 72){
              sizeResult.html('S');  
            }
            else{
              sizeResult.html('M');    
            }
        }
        if (currentWeight > 60 && currentWeight <= 80){
            if(e <= 60){
              sizeResult.html('S');  
            }
            else if(e > 60 && e < 72){
              sizeResult.html('M');  
            }
            else{
              sizeResult.html('L');  
            }
        }
        if (currentWeight > 80 && currentWeight <= 100){
            if(e <= 60){
              sizeResult.html('M');  
            }
            else{
              sizeResult.html('L');  
            }
        }
        if (currentWeight > 100 && currentWeight <= 120){
            if(e <= 60){
              sizeResult.html('L');  
            }
            else{
              sizeResult.html('XL');  
            }
        }
        if (currentWeight > 121 && currentWeight <= 160){
            if(e <= 60){
              sizeResult.html('L');  
            }
            else{
              sizeResult.html('XL');  
            }
        }
    };
    
    var setSizeWithWeight = function(e){
        var currentHeight = ($('.height-result')).text() * 12;
        if (currentHeight <= 60){
            if(e <= 70){
              sizeResult.html('S');  
            }
            else{
              sizeResult.html('M');    
            }
        }
        if (currentHeight > 60 && currentHeight <= 72){
            if(e <= 60){
              sizeResult.html('S');  
            }
            else if(e > 60 && e <= 80){
              sizeResult.html('M');  
            }
            else if(e > 80 && e <= 120){
              sizeResult.html('L');  
            }
            else{
              sizeResult.html('XL');  
            }
        }
        if (currentHeight > 72 && currentHeight <= 84){
            if(e <= 80){
              sizeResult.html('L');  
            }
            else{
              sizeResult.html('XL');  
            }
        }
        if (currentHeight > 84){
            if(e <= 60){
              sizeResult.html('L');  
            }
            else{
              sizeResult.html('XL');  
            }
        }
    };
    
    
    heightPicker.rangeslider({
        polyfill: false,
        onInit: function(){
            updateOutput(heightResult[0], (this.value / 12).toFixed(1));
        }
    })
    .on('input', function() {
        updateOutput(heightResult[0], (this.value / 12).toFixed(1));
        setSizeWithHeight(this.value);
    });
    
    weightPicker.rangeslider({
        polyfill: false,
        onInit: function(){
            updateOutput(weightResult[0], this.value);
        }
    })
    .on('input', function() {
        updateOutput(weightResult[0], this.value);
        setSizeWithWeight(this.value);
    });
    
    
    $('#popup-primary').click(function(){
        $("#size-picker").fadeOut(100);
        $(".popup-overlay").remove();
    });
    
    var generateOrderNumber = function(e){
        var currentOrderNumber = parseInt(e.text(), 10)
        var endDigits  = currentOrderNumber % 100; /*get last 2 digits*/
        var newOrderNumber = currentOrderNumber + 11; /*default increment value*/
        if(endDigits > 90 && endDigits <= 99){
            $(e).text(newOrderNumber + 1);
        }
        else{
            $(e).text(newOrderNumber);
        }
    };
    
    
    $('a#order-generate').click(function(){
        event.preventDefault();
        var orderNumber = $('#order-number');
        generateOrderNumber(orderNumber);
        
    });
    

});
