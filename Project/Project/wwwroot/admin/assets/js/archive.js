

let categoryArchiveBtns = document.querySelectorAll(".add-archive")

categoryArchiveBtns.forEach(item =>
    item.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        (async () => {
            const rawResponse = await fetch(`category/settoarchive?id=${id}`, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
            });

            this.closest(".c-data").remove();
        })();
    })
)

let arcArchiveBtns = document.querySelectorAll(".remove-archive")

arcArchiveBtns.forEach(item =>
    item.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        (async () => {
            const rawResponse = await fetch(`archive/restorefromarchive?id=${id}`, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
            });

            this.closest(".c-data").remove();
        })();
    })
)