$("#NavigationBar").load("navigation.html", 
    () => $(".nav a")
        .filter((i, obj) => window.location.href.indexOf(obj.getAttribute("href")) != -1)
        .each((i, obj) => obj.parentNode.classList.add("active")));