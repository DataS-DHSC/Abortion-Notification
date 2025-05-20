// app/routes/index.js

const govukPrototypeKit = require('govuk-prototype-kit')
const router            = govukPrototypeKit.requests.setupRouter()

// 1) GLOBAL NAV MIDDLEWARE
router.use((req, res, next) => {
  // build your raw nav links
  const rawNav = [
    { href: '/forms',    text: 'Forms'      },
    { href: '/profile',  text: 'My profile' },
    { href: '/sign-out', text: 'Sign out'   }
  ]

  // mark active by comparing to req.path
  res.locals.navigation = rawNav.map(item => ({
    ...item,
    active: item.href === req.path
  }))

  next()
})

module.exports = router
