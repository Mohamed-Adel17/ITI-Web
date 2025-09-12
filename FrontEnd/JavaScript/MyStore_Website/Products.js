let productsDiv = document.getElementById('product-list');

async function processDataFromAPI(_link) {
  try {
    let rawProducts = await fetch(_link);
    let products = await rawProducts.json();
    console.log(products);
    displayProducts(products);
    handleButtonClicks();
  } catch (error) {
    console.log(`Fetching data failed!! ... ${error}`);
  }
}

function displayProducts(_products) {
  let rowContent = '';
  for (let i = 0; i < _products.length; i++) {
    rowContent += createColumn(_products[i]);

    //check if reaching end of row, or end of product list
    if ((i + 1) % 3 == 0 || _products.length == i + 1) {
      productsDiv.innerHTML += `<div class="row">${rowContent}</div>`;
      rowContent = '';
    }
  }
}

function createColumn(product) {
  return `
        <div class="col-sm-6 col-lg-4 mb-4">
            <div class="card h-100">
                <img src="${product.image}" class="card-img-top" />
                <div class="card-body">
                    <h5 class="card-title">${product.title}</h4>
                    <p class="card-text">${product.description}</p>
                </div>
                <div class="card-footer">
                    <p>${product.price}$</p>
                    <button class="add-to-cart" data-id = "${product.id}">Add to card</button>
                </div>
            </div>
        </div>
    `;
}

processDataFromAPI('https://fakestoreapi.com/products');

let handleButtonClicks = function () {
  let buttonsClicked = document.querySelectorAll('.add-to-cart');
  buttonsClicked.forEach(button => {
    button.addEventListener('click', e => {
      const productId = e.target.dataset.id;

      let cart = JSON.parse(localStorage.getItem('cart')) || [];
      const product = cart.find(prd => prd.id == productId);
      if (product) {
        product.amount++;
      } else {
        const element = { id: productId, amount: 1 };
        cart.push(element);
      }

      localStorage.setItem('cart', JSON.stringify(cart));
      window.location.href = 'Cart.html';
    });
  });
};
