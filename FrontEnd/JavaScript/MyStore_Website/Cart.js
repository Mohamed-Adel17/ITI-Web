async function processCartItems() {
  //retrieve cart items IDs from local storage if found
  let productStored = JSON.parse(localStorage.getItem('cart')) || [];
  let contentDiv = document.getElementsByClassName('cart-content')[0];
  if (productStored.length == 0) {
    contentDiv.innerHTML = `<p>Your cart is empty.</p>`;
    return;
  }

  let rawProducts = await fetch('https://fakestoreapi.com/products');
  let products = await rawProducts.json();
  let cartProducts = [];
  let prd = null;
  for (let i = 0; i < productStored.length; i++) {
    prd = products.find(product => {
      return product.id == productStored[i].id;
    });
    prd.amount = productStored[i].amount;
    cartProducts.push(prd);
  }

  updateCartContent(cartProducts);

  handleAddReduceClicks(cartProducts);
}

function updateCartContent(cartProducts) {
  let content = displayCartProducts(cartProducts);
  const cartItemsBody = document.getElementById('cart-items');
  cartItemsBody.innerHTML = content;
}

function handleAddReduceClicks(cartProducts) {
  const cartItemsBody = document.getElementById('cart-items');

  cartItemsBody.addEventListener('click', e => {
    isAdd = e.target.classList.contains('add-quantity');
    isReduce = e.target.classList.contains('reduce-quantity');
    isRemove = e.target.classList.contains('remove-item');
    if (isAdd || isReduce || isRemove) {
      const row = e.target.closest('tr');
      const prdId = row.dataset.id;
      let prod = cartProducts.find(p => p.id == prdId);
      if (isAdd) {
        prod.amount++;
        updateLocalStorage(prod);
        updateCartContent(cartProducts);
      } else if (isReduce) {
        prod.amount--;

        if (prod.amount <= 0) {
          cartProducts = cartProducts.filter(el => {
            return el.id != prod.id;
          });
        }
        updateLocalStorage(prod);
        updateCartContent(cartProducts);
      } else {
        prod.amount = 0;

        cartProducts = cartProducts.filter(el => {
          return el.id != prod.id;
        });
      }
      updateLocalStorage(prod);
      updateCartContent(cartProducts);
    }
  });
}

function updateLocalStorage(prod) {
  let cart = JSON.parse(localStorage.getItem('cart'));
  if (prod.amount == 0) {
    cart = cart.filter(el => {
      return el.id != prod.id;
    });
  } else {
    cart.find(el => {
      return el.id == prod.id;
    }).amount = prod.amount;
  }
  localStorage.setItem('cart', JSON.stringify(cart));
}

function displayCartProducts(products) {
  let content = '';
  products.forEach(product => {
    content += `
        <tr data-id="${product.id}">
                <td class="card-title "><img class=" img-left" src="${
                  product.image
                }"/>
                ${truncateTitle(product.title, 45)}</td>
                <td>$${(product.price * product.amount).toFixed(2)}</td>
                <td>
                    <button class="btn btn-sm btn-outline-secondary reduce-quantity">-</button>
                    <span>${product.amount}</span>
                    <button class="btn btn-sm btn-outline-secondary add-quantity">+</button>
                </td>
                
                <td>
                    <button class="btn btn-sm btn-danger remove-item">Remove</button>
                </td>
            </tr>
    `;
  });
  return content;
}
function truncateTitle(title, maxLength) {
  if (title.length > maxLength) {
    return title.substring(0, maxLength) + '...';
  }
  return title;
}
processCartItems();
