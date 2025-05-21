// livre/index.cshtml
function updatePanierCount() {
        const panier = JSON.parse(localStorage.getItem('panier')) || [];
        const badge = document.getElementById('panier-count');
        if (badge) badge.textContent = panier.length;
    }

    window.addEventListener('panier-updated', updatePanierCount);
     window.addEventListener('storage', function (e) {
        console.log(e);
        if (e.key === 'panier') {
            updatePanierCount();
        }
    });
    document.addEventListener('DOMContentLoaded', updatePanierCount);

// shared/_Layout.cshtml
       function addToCart(button) {
        const book = {
            id: button.dataset.livreId,
            titre: button.dataset.livreTitre,
            image: button.dataset.livreImageurl
        };

        let panier = JSON.parse(localStorage.getItem('panier')) || [];

        if (!panier.some(b => b.id == book.id)) {
            panier.push(book);
            localStorage.setItem('panier', JSON.stringify(panier));
            window.dispatchEvent(new Event('panier-updated'));
            alert(`"${book.titre}" ajouté au panier.`);
        } else {
            alert(`"${book.titre}" est déjà dans le panier.`);
        }
    }