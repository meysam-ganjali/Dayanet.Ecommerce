(function ($) {
    "use strict";
    $(".hamburger").on("click", function (event) {
        $(this).toggleClass("h-active");
        $(".main-nav").toggleClass("slidenav");
    });
    $(".header-home .main-nav ul li  a").on("click", function (event) {
        $(".hamburger").removeClass("h-active");
        $(".main-nav").removeClass("slidenav");
    });
    $(".main-nav .fl").on("click", function (event) {
        var $fl = $(this);
        $(this).parent().siblings().find(".sub-menu").slideUp();
        $(this).parent().siblings().find(".fl").addClass("flaticon-plus").text("+");
        if ($fl.hasClass("flaticon-plus")) {
            $fl.removeClass("flaticon-plus").addClass("flaticon-minus").text("-");
        } else {
            $fl.removeClass("flaticon-minus").addClass("flaticon-plus").text("+");
        }
        $fl.next(".sub-menu").slideToggle();
    });
    document.querySelectorAll(".cart-icon i").forEach((element) => {
        element.addEventListener("click", () => {
            document.querySelectorAll(".cart-sidebar-wrappper").forEach((element) => element.classList.add("cart-active"));
        });
    });
    document.querySelectorAll(".cart-close-icon i").forEach((element) => {
        element.addEventListener("click", () => {
            document.querySelectorAll(".cart-sidebar-wrappper").forEach((element) => element.classList.remove("cart-active"));
        });
    });
    window.onclick = function (event) {
        document.querySelectorAll(".cart-sidebar-wrappper").forEach((el) => {
            if (event.target === el) {
                el.classList.remove("cart-active");
            }
        });
    };
    document.querySelectorAll(".category-icon i").forEach((element) => {
        element.addEventListener("click", () => {
            document.querySelectorAll(".category-bar").forEach((bar) => {
                if (bar.classList.contains("active")) {
                    bar.classList.remove("active");
                } else {
                    bar.classList.add("active");
                }
            });
        });
    });
    var x, i, j, l, ll, selElmnt, a, b, c;
    x = document.getElementsByClassName("custom-select");
    l = x.length;
    for (i = 0; i < l; i++) {
        selElmnt = x[i].getElementsByTagName("select")[0];
        ll = selElmnt.length;
        a = document.createElement("DIV");
        a.setAttribute("class", "select-selected");
        a.innerHTML = selElmnt.options[selElmnt.selectedIndex].innerHTML;
        x[i].appendChild(a);
        b = document.createElement("DIV");
        b.setAttribute("class", "select-items select-hide");
        for (j = 1; j < ll; j++) {
            c = document.createElement("DIV");
            c.innerHTML = selElmnt.options[j].innerHTML;
            c.addEventListener("click", function (e) {
                var y, i, k, s, h, sl, yl;
                s = this.parentNode.parentNode.getElementsByTagName("select")[0];
                sl = s.length;
                h = this.parentNode.previousSibling;
                for (i = 0; i < sl; i++) {
                    if (s.options[i].innerHTML === this.innerHTML) {
                        s.selectedIndex = i;
                        h.innerHTML = this.innerHTML;
                        y = this.parentNode.getElementsByClassName("same-as-selected");
                        yl = y.length;
                        for (k = 0; k < yl; k++) {
                            y[k].removeAttribute("class");
                        }
                        this.setAttribute("class", "same-as-selected");
                        break;
                    }
                }
                h.click();
            });
            b.appendChild(c);
        }
        x[i].appendChild(b);
        a.addEventListener("click", function (e) {
            e.stopPropagation();
            closeAllSelect(this);
            this.nextSibling.classList.toggle("select-hide");
            this.classList.toggle("select-arrow-active");
        });
    }
    function closeAllSelect(elmnt) {
        var x,
            y,
            i,
            xl,
            yl,
            arrNo = [];
        x = document.getElementsByClassName("select-items");
        y = document.getElementsByClassName("select-selected");
        xl = x.length;
        yl = y.length;
        for (i = 0; i < yl; i++) {
            if (elmnt === y[i]) {
                arrNo.push(i);
            } else {
                y[i].classList.remove("select-arrow-active");
            }
        }
        for (i = 0; i < xl; i++) {
            if (arrNo.indexOf(i)) {
                x[i].classList.add("select-hide");
            }
        }
    }
    document.addEventListener("click", closeAllSelect);
    $(window).on("scroll", function () {
        var scroll = $(window).scrollTop();
        if (scroll >= 20) {
            $(".header-area").addClass("sticky");
            $(".category-bar").addClass("category-sticky");
        } else {
            $(".header-area").removeClass("sticky");
            $(".category-bar").removeClass("category-sticky");
        }
    });
    $("#slider-range").slider({
        range: true,
        isRTL: true,
        min: 130,
        max: 500,
        values: [130, 250],
        slide: function (event, ui) {
            $("#amount").val("" + ui.values[0] + " - " + ui.values[1]);
        },
    });
    $("#amount").val("" + $("#slider-range").slider("values", 0) + " - " + $("#slider-range").slider("values", 1));
    jQuery('<div class="quantity-nav"><div class="quantity-button quantity-up"><i class="bi bi-plus"></i></div><div class="quantity-button quantity-down"><i class="bi bi-dash"></i></div></div>').insertAfter(".quantity input");
    jQuery(".quantity").each(function () {
        var spinner = jQuery(this),
            input = spinner.find('input[type="number"]'),
            btnUp = spinner.find(".quantity-up"),
            btnDown = spinner.find(".quantity-down"),
            min = input.attr("min"),
            max = input.attr("max");
        btnUp.on("click", function () {
            var oldValue = parseFloat(input.val());
            if (oldValue >= max) {
                var newVal = oldValue;
            } else {
                var newVal = oldValue + 1;
            }
            spinner.find("input").val(newVal);
            spinner.find("input").trigger("change");
        });
        btnDown.on("click", function () {
            var oldValue = parseFloat(input.val());
            if (oldValue <= min) {
                var newVal = oldValue;
            } else {
                var newVal = oldValue - 1;
            }
            spinner.find("input").val(newVal);
            spinner.find("input").trigger("change");
        });
    });
    function timeConverter(UNIX_timestamp) {
        var a = new Date(UNIX_timestamp * 1000);
        var months = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        var year = a.getFullYear();
        var month = months[a.getMonth()];
        var date = a.getDate();
        var hour = a.getHours();
        var min = a.getMinutes();
        var sec = a.getSeconds();
        var time = date + " " + month + " " + year + " " + hour + ":" + min + ":" + sec;
        console.log(date);
        $("#timer #days").html(date);
        $("#timer #hours").html(hour);
        $("#timer #minutes").html(min);
        $("#timer #seconds").html(sec);
    }
    function makeTimer() {
        var endTime = new Date("September 01, 2022 00:00:00");
        var endTime = Date.parse(endTime) / 1000;
        var now = new Date();
        var now = Date.parse(now) / 1000;
        var timeLeft = endTime - now;
        var days = Math.floor(timeLeft / 86400);
        var hours = Math.floor((timeLeft - days * 86400) / 3600);
        var Xmas95 = new Date("December 25, 1995 23:15:30");
        var hour = Xmas95.getHours();
        var minutes = Math.floor((timeLeft - days * 86400 - hours * 3600) / 60);
        var seconds = Math.floor(timeLeft - days * 86400 - hours * 3600 - minutes * 60);
        if (hours < "10") {
            hours = "0" + hours;
        }
        if (minutes < "10") {
            minutes = "0" + minutes;
        }
        if (seconds < "10") {
            seconds = "0" + seconds;
        }
        $("#timer #days").html(days);
        $("#timer #hours").html(hours);
        $("#timer #minutes").html(minutes);
        $("#timer #seconds").html(seconds);
    }
    setInterval(function () {
        makeTimer();
    }, 1000);
    $("[data-fancybox]").fancybox({ youtube: { controls: 0, showinfo: 0 }, vimeo: { color: "f00" } });
    var heroSlider = new Swiper(".swiper-container", {
        loop: true,
        effect: "fade",
        fadeEffect: { crossFade: true },
        autoplay: { delay: 7000 },
        navigation: { nextEl: ".swiper-button-next", prevEl: ".swiper-button-prev" },
        pagination: { el: ".swiper-pagination" },
    });
    var trandingSlider = new Swiper(".swiper-tranding-container", {
        loop: true,
        spaceBetween: 24,
        slidesPerView: 6,
        autoplay: { delay: 7000 },
        navigation: { nextEl: ".swiper-button-next", prevEl: ".swiper-button-prev" },
        pagination: { el: ".swiper-pagination" },
        breakpoints: { 500: { slidesPerView: 1 }, 700: { slidesPerView: 2 }, 950: { slidesPerView: 3 }, 1000: { slidesPerView: 3 }, 1400: { slidesPerView: 4 }, 1800: { slidesPerView: 5 } },
    });
    var blogSlider = new Swiper(".swiper-blog-container", {
        loop: true,
        spaceBetween: 24,
        slidesPerView: 4,
        autoplay: { delay: 7000 },
        navigation: { nextEl: ".swiper-button-next", prevEl: ".swiper-button-prev" },
        pagination: { el: ".swiper-pagination" },
        breakpoints: { 625: { slidesPerView: 1 }, 1000: { slidesPerView: 2 }, 1700: { slidesPerView: 3 }, 1920: { slidesPerView: 4 }, 2420: { slidesPerView: 5 } },
    });
})(jQuery);
