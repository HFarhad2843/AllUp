let addToBasketButtons = document.querySelectorAll(".add-basket");

addToBasketButtons.forEach(btn => {
    btn.addEventListener("click", function (e) {
        e.preventDefault();

        let url = btn.getAttribute("href");

        fetch(url)
            .then(response => {
                if (response.status == 200) {
                    alert("elave olundu");
                    location.reload();

                } else {
                    throw new Error("xeta bas verdi");
                }
            })
            .then(data => {
            })
            .catch(error => {
                console.error("Error:", error);
                alert("xeta bas verdi ");
            });
    });
});