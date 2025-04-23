function saveAnswer(req, section, values) {
    if (!req.session.data[section]) {
      req.session.data[section] = {};
    }
  
    req.session.data[section] = {
      ...req.session.data[section],
      ...values
    };
  }
  
  module.exports = {
    saveAnswer
  };
  