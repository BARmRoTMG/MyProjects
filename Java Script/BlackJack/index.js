let player = {
    name: "Bar",
    chips: 200
}

let cards = []
let dealerCards = []
let sum = 0
let dealerSum = 0
let hasBlackJack = false
let isAlive = false
let message = ""
let messageEl = document.getElementById("message-el")
let sumEl = document.getElementById("sum-el")
let cardsEl = document.getElementById("cards-el")
let playerEl = document.getElementById("player-el")
let dealerCardsEl = document.getElementById("dealer-cards-el")
let dealerSumEl = document.getElementById("dealer-sum-el")
let finishBtn = document.getElementById("finishBtn")

playerEl.textContent = player.name + ": $" + player.chips

function getRandomCard() {
    let randomNumber = Math.floor(Math.random() * 13) + 1
    if (randomNumber > 10) {
        return 10
    } else if (randomNumber === 1) {
        return 11
    } else {
        return randomNumber
    }
}

function startGame() {
    finishBtn.disabled = false;
    isAlive = true
    let firstCard = getRandomCard()
    let secondCard = getRandomCard()
    let dealerFirstCard = getRandomCard();
    let dealerSecondCard = getRandomCard();
    cards = [firstCard, secondCard]
    dealerCards = [dealerFirstCard, dealerSecondCard]
    sum = firstCard + secondCard
    dealerSum = dealerFirstCard
    renderGame()
}

function renderGame() {
    cardsEl.textContent = "Cards: "
    for (let i = 0; i < cards.length; i++) {
        cardsEl.textContent += cards[i] + " "
    }

    dealerCardsEl.textContent = "Cards: " + dealerCards[0];
    dealerSumEl.textContent = "Sum: " + dealerSum

    sumEl.textContent = "Sum: " + sum
    if (sum <= 20) {
        message = "Do you want to draw a new card?"
    } else if (sum === 21) {
        message = "You've got Blackjack!"
        hasBlackJack = true
    } else {
        message = "You're out of the game!"
        isAlive = false
    }
    messageEl.textContent = message
}


function newCard() {
    if (isAlive === true && hasBlackJack === false) {
        let card = getRandomCard()
        sum += card
        cards.push(card)
        renderGame()
    }
}

function finish() {
    dealerCardsEl.textContent += " " + dealerCards[1];
    dealerSum += dealerCards[1];
    dealerSumEl.textContent = "Sum: " + dealerSum;

    if (sum < dealerSum && dealerSum <= 21) {
        messageEl.textContent = "The dealer won!"
    } else if (sum == dealerSum) {
        messageEl.textContent = "It's a draw!"
    } else {
        messageEl.textContent = "You win!"
    }

    finishBtn.disabled = true;

    var millisecondsToWait = 3000;
    setTimeout(function () {
        startGame()
    }, millisecondsToWait);
}